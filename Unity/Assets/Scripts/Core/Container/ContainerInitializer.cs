using Wem.Agenda;
using Wem.Yaml;
using Wem.Map;

namespace Wem.Container {

  public class ContainerInitiazer {

    /**
     * Initializes all the essentials services.
     *
     * @param IContainer container
     *   The service container where to store the services.
     */
    public static void Initialize(IContainer container) {
      /*
       * These services do not depend on anything.
       */
      container.Set("map", Map.Map.create(container));
      container.Set("agenda.container", AgendaContainer.create(container));
      container.Set("agenda.generator", AgendaGenerator.create(container));
      container.Set("yaml.agenda.deserializer", AgendaDeserializer.create(container));
      container.Set("yaml.map.deserializer", MapDeserializer.create(container));

      /*
       * These services depends on other services.
       */
      container.Set("map.initializer", MapInitializer.create(container));

      // Agenda Initializer expects the map to be fully initialized.
      container.Set("agenda.initializer", AgendaInitializer.create(container));
    }

  }

}
