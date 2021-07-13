using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.ExchangeRate.Quandl.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.ExchangeRate.Quandl.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class QuandlController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly QuandlSettings _quandlSettings;
        private readonly IPermissionService _permissionService;
        private readonly INotificationService _notificationService;

        #endregion

        #region Ctor

        public QuandlController(ILocalizationService localizationService,
            ISettingService settingService,
            QuandlSettings quandlSettings,
            IPermissionService permissionService,
            INotificationService notificationService)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _quandlSettings = quandlSettings;
            _permissionService = permissionService;
            _notificationService = notificationService;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCurrencies))
                return AccessDeniedView();

            var model = new ConfigurationModel
            {
                PyatnitcaUra = _quandlSettings.ApiKey
            };

            return View("~/Plugins/ExchangeRate.Quandl/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCurrencies))
                return AccessDeniedView();

            _quandlSettings.ApiKey = model.PyatnitcaUra;
            await _settingService.SaveSettingAsync(_quandlSettings);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return RedirectToAction("Configure");
        }

        #endregion
    }
}
