using Microsoft.Extensions.FileProviders;
using PlayersWebAPI.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersWebAPI.Core
{
    /// <summary>
    /// Permet de convertir un fichier Json en un tableau d'objets
    /// </summary>
    /// <typeparam name="TResource">Type d'objet de retour</typeparam>
    public interface IResourceHelper<TResource>
    {
        IList<TResource> GetValues();

        TResource GetValue(Func<TResource, bool> predicate);
    }

    public class ResourceHelper<TResource> : IResourceHelper<TResource>
    {
        private readonly IList<TResource> resourceContent;

        public ResourceHelper(IFileProvider resourcesFileProvider, string resourceFile)
        {
            var fichier = resourcesFileProvider.GetFileInfo(resourceFile);
            resourceContent = fichier.CreateReadStream().DeserializeJson<IList<TResource>>();
        }

        public IList<TResource> GetValues()
         => resourceContent.ToList();

        public TResource GetValue(Func<TResource, bool> predicate)
            => resourceContent
                .FirstOrDefault(predicate);
    }
}
