using Microsoft.AspNetCore.Mvc;
using ValidationAutomapperHomework.Validators.Data_Annotations;

namespace ValidationAutomapperHomework.View_Models
{
    [ModelMetadataType(typeof(LoginValidator))]
    public class LoginViewModel
    {
        public string? Username { get; set; }
     
        public string? Password { get; set; }
    }
}
