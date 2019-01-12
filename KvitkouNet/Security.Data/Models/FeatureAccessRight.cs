namespace Security.Data.Models
{
    /// <summary>
    /// Многие ко многим Feature и AccessRight
    /// </summary>
    internal class FeatureAccessRight
    {
        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public int AccessRightId { get; set; }

        public AccessRight AccessRight { get; set; }
    }
}
