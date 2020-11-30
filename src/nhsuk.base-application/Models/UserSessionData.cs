using System;
using nhsuk.base_application.ViewModels;

namespace nhsuk.base_application.Models
{
    internal sealed class UserSessionData
    {
        public UserSessionData()
        {
            Id = new Guid();
            Address = new AddressViewModel();
        }

        public Guid Id { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
