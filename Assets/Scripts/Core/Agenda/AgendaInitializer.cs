using System.Collections.Generic;
using Wem.Container;
using Wem.Yaml;

namespace Wem.Agenda {

  public class AgendaInitializer {

    /**
     * The agenda container.
     */
    protected AgendaContainer container;

    /**
     * The agenda generator.
     */
    protected AgendaGenerator generator;

    /**
     * The YAML file deserializer for agendas.
     */
    protected AgendaDeserializer deserializer;

    public AgendaInitializer(AgendaContainer container,
                             AgendaGenerator generator) {

      this.container = container;
      this.generator = generator;
    }

    public static AgendaInitializer create(IContainer container) {
      return new AgendaInitializer(
        (AgendaContainer) container.Get("agenda.container"),
        (AgendaGenerator) container.Get("agenda.generator")
      );
    }

    public void  InitializeAgendas(List<string> files) {

    }

  }

}
