using Geent.Application.DTOs.Request;
using Geent.Application.DTOs.Response;
using Geent.Application.Interface.Service;
using Geent.Domain.Entidade;
using Geent.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task RegisterUserAsync(UserRegisterRequestDto userRegisterDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userRegisterDto.Email);
            if (existingUser != null)
                throw new Exception("Usuário já existe com esse email.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);
            
            var verificationCode = GenerateVerificationCode();

            await SendVerificationEmail(userRegisterDto.Email, verificationCode);

            var user = new User
            {
                Nome = userRegisterDto.Nome,
                Email = userRegisterDto.Email,
                Password = hashedPassword,
                Telefone = userRegisterDto.Telefone,
                TipoUsuario = userRegisterDto.TipoUsuario,
                DataCriacao = DateTime.UtcNow,
                FirstAcess = true,
                VerificationCode = verificationCode,
                IsVerified = false,
                VerificationCodeExpiration = DateTime.UtcNow.AddHours(1) 
            };

            await _userRepository.AddUserAsync(user);

         
        }
        
        public async Task VerifyUserAsync(string email, string code)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            if (user.IsVerified)
                throw new Exception("Usuário já está verificado.");

            if (user.VerificationCode != code || user.VerificationCodeExpiration < DateTime.UtcNow)
                throw new Exception("Código de verificação inválido ou expirado.");

            user.IsVerified = true;
            user.VerificationCode = null; 
            user.VerificationCodeExpiration = null;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<UserResponseDto> GetCurrentUserAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            return new UserResponseDto
            {
                Nome = user.Nome,
                Email = user.Email,
                Telefone = user.Telefone,
                TipoUsuario = user.TipoUsuario
            };
        }

        private async Task SendVerificationEmail(string email, string code)
        {
            var subject = "Verificação de Conta";
            var body = $"<p>Seu código de verificação é: <b>{code}</b></p>";
            await _emailService.SendEmailAsync(email, subject, body);
        }


        private static string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task UpdateUserAsync(string email, UserUpdateRequestDto userUpdateDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            user.Nome = userUpdateDto.Name ?? user.Nome;
            user.Telefone = userUpdateDto.Phone ?? user.Telefone;
            user.FirstAcess = false;

            await _userRepository.UpdateUserAsync(user);
        }

    }

}
