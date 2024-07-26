using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IUtility
{
    public interface IFileUtility
    {
        Task<string> SaveImage(IFormFile file, string type);
    }
}
