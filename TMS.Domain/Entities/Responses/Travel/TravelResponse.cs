using System;
using TMS.Domain.Entites.Responses.Vehicle;
using TMS.Domain.Entities.Responses.Vehicle;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Responses.Travel
{
    public class TravelResponse
    {
        public Guid Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public AddressVO Origin { get; private set; }
        public AddressVO Destination { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsCanceled { get; private set; }

        // Pode ser preenchido via projeção
        public VehicleSummaryResponse? Vehicle { get; set; }

        // Construtor para facilitar projeções (Select new TravelResponse(...))
        public TravelResponse(
            Guid id,
            DateTime startDate,
            DateTime endDate,
            AddressVO origin,
            AddressVO destination,
            LoadVO load,
            decimal price,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isCanceled)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Origin = origin;
            Destination = destination;
            Load = load;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsCanceled = isCanceled;
        }

        // Construtor sem parâmetros para serialização, se necessário
        private TravelResponse() { }
    }
}