using Wem.Agenda;
using Wem.Yaml;

namespace Wem.Container {

  public class ContainerInitiazer {

    /**
     * Initializes all the essentials services.
     *
     * @param IContainer container
     *   The service container where to store the services.
     */
    public static void Initialize(IContainer container) {
      container.Set("yaml.agenda.deserializer", AgendaDeserializer.create(container));
      container.Set("agenda.generator", AgendaGenerator.create(container));
      container.Set("agenda.container", AgendaContainer.create(container));

      container.Set("agenda.initializer", AgendaInitializer.create(container));
    }

  }

}
