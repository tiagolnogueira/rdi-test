using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RDI.Test.Application.Interfaces;
using RDI.Test.Application.Notifications;
using System;
using System.Linq;

namespace RDI.Test.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificator notificator,
                                 IUser appUser)
        {
            _notificator = notificator;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool IsValid()
        {
            return !_notificator.AnyNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ErrorNotification(errorMsg);
            }
        }

        protected void ErrorNotification(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }
    }
}
