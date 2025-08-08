using System.IO;

namespace Rifoms.Domain.Infrastructure.Config
{
    public class PathConfig
    {
        private static string relativeWebImagesPath = @"\Rifoms.Web\wwwroot\images\";
        public static string WebImagesPath { get { return $"{Directory.GetParent(@"../../../../").FullName}{relativeWebImagesPath}"; } }
    }
}
