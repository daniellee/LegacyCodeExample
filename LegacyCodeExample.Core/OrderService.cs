using System.IO;
using System.Net.Mail;

namespace LegacyCodeExample.Core
{
    public class OrderService
    {
        private const string DatabaseConnectionString = "dummy";
        private readonly SmtpClient smtpClient;
        private readonly OrderRepository orderRepository;
        private const string DefaultSender = "production@activesolution.se";

        public OrderService()
        {
            orderRepository = new OrderRepository(DatabaseConnectionString);
            smtpClient = new SmtpClient { UseDefaultCredentials = true };
        }

        public void SendOrderConfirmationToCustomer(int orderId)
        {
            Order order = orderRepository.GetOrderById(orderId);

            var email = new MailMessage(DefaultSender, order.CustomerEmailAddress)
            {
                Subject = "Order Confirmation",
                Body = BuildOrderConfirmationMessage()
            };
            smtpClient.Send(email);
        }

        private string BuildOrderConfirmationMessage()
        {
            return "This needs to be tested that it is correct";
        }

        public void SaveOrder(Order order)
        {
            Order oldOrder = orderRepository.GetOrderById(order.Id);
            
            string diff = GetOrderChanges(oldOrder, order);
            SaveOrderDiffToFile(diff);

            orderRepository.Save(order);
        }

        private string GetOrderChanges(Order oldOrder, Order order)
        {
            if (oldOrder.CustomerEmailAddress != order.CustomerEmailAddress)
                return order.CustomerEmailAddress;

            return "";
        }

        private void SaveOrderDiffToFile(string diff)
        {
            using (StreamWriter outfile = new StreamWriter("DirectoryThatDoesNotExist\\FileThatDoesNotExist.txt"))
            {
                outfile.Write(diff);
            }
        }
    }
}