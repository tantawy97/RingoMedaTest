
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Client.EmailClient.Interfaces
{
    public interface IViewRender
    {
        public string Render<TModel>(string name, TModel model);
        string Render<TModel>(string templatePath, TModel model, ViewDataDictionary? viewData);
    }
}
