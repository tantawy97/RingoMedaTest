using Client.EmailClient.Interfaces;
using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Client.EmailClient.Services
{
    public class HandlebarsService : IViewRender
    {
        public string Render<TModel>(string templatePath, TModel model)
        {
            return Render(templatePath, model, null);
        }

        public string Render<TModel>(string templatePath, TModel model, ViewDataDictionary? viewData)
        {
            var template = Handlebars.Compile(templatePath);
            var result = template(model);
            return result;
        }
    }
}
