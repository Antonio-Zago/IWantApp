using Flunt.Notifications;

namespace IWantApp.Domain
{
    public abstract class Entity : Notifiable<Notification> //Flunt
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string EditedBy { get; set; }

        public DateTime EditedOn { get; set; }
    }
}
