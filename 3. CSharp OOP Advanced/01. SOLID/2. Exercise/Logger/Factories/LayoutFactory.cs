using Logger.Contracts;
using Logger.Models.Layouts;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
            }

            return layout;
        }
    }
}