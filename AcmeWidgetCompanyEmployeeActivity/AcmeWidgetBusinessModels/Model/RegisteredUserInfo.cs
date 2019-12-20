using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetBusinessModels.Data.Model
{
    public class RegisteredUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        public string ActivityName { get; set; }

        public int ActivityId { get; set; }


    }
}
