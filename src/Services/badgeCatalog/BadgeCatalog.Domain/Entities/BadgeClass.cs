using BadgeCatalog.Domain.ValueObjects;
using BadgeCatalog.Domain.Enums;
    using BadgeCatalog.Domain.Events;
namespace BadgeCatalog.Domain.Entities;

public class BadgeClass : Entity
{
    #region Properties
    
        public string Name { get; private set; }           // Badge name
        public string Description { get; private set; }    // Achievement description
        public string ImageUrl { get; private set; }       // Badge image URL
        public Criteria Criteria { get; set; }     // Value Object
        public IssuerRef Issuer { get; private set; }      // Value Object
        public BadgeStatus Status { get; private set; }    // Active/Inactive
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

    #endregion
    #region Constructors
    private BadgeClass() { } // For EF Core
   
public BadgeClass(string name, string description, string imageUrl, Criteria criteria, IssuerRef issuer)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Criteria = criteria;
            Issuer = issuer;
            Status = BadgeStatus.Active;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

    #endregion

    #region Methods
    
    
    #endregion
}