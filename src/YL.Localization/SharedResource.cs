using Microsoft.Extensions.Localization;


namespace YL.Localization
{
    public interface ISharedResource
    {
        string this[string index] { get; }
    }

    public class SharedResource : ISharedResource
    {
        private readonly IStringLocalizer _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public string this[string index]
        {
            get
            {
                return _localizer[index];
            }
        }
    }
}
