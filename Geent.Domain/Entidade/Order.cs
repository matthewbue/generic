using System;
using System.Collections.Generic;
using System.Linq;

namespace Geent.Domain.Entidade
{
    public class Order
    {
        public int Id { get; set; }

        public string? ClientName { get; set; } // Nome do cliente que fez o pedido

        public string? ClientAddress { get; set; } // Endereço do cliente

        public PaymentMethod MethodPayment { get; set; } // Enum para método de pagamento

        public DateTime OrderDate { get; set; } = DateTime.Now; // Data do pedido, inicializada como a data atual

        public List<OrderItem> Items { get; set; } = new List<OrderItem>(); // Lista de itens no pedido

        public decimal TotalValue => CalculateTotalValue(); // Valor total do pedido, calculado dinamicamente

        public OrderStatus Status { get; set; } = OrderStatus.Pending; // Status do pedido, padrão como "Pendente"

        // Método para calcular o valor total
        private decimal CalculateTotalValue()
        {
            return Items?.Sum(item => item.Quantity * item.Item.Price) ?? 0;
        }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; } // ID do item do pedido
        public Item Item { get; set; } = new Item(); // Dados do item
        public int Quantity { get; set; } // Quantidade do item no pedido
    }
    public enum OrderStatus
    {
        Pending,      // Pedido pendente
        InPreparation, // Em preparo
        Ready,        // Pronto para entrega/retirada
        Delivered,    // Entregue
        Cancelled     // Cancelado
    }

    public enum PaymentMethod
    {
        Cash,          // Dinheiro
        CreditCard,    // Cartão de crédito
        DebitCard,     // Cartão de débito
        Pix,           // Pagamento por Pix
        OnlinePayment  // Pagamento online
    }
}
