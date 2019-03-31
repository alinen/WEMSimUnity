using System.Collections.Generic;
using Wem.Activity;
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

    public static AgendaInitializer create(IContainer container) {
      return new AgendaInitializer(
        (AgendaContainer) container.Get("agenda.container"),
        (AgendaGenerator) container.Get("agenda.generator"),
        (AgendaDeserializer) container.Get("yaml.agenda.deserializer")
      );
    }

    /**
     * AgendaInitializer constructor.
     */
    public AgendaInitializer(AgendaContainer container,
                             AgendaGenerator generator,
                             AgendaDeserializer deserializer) {

      this.container = container;
      this.generator = generator;
      this.deserializer = deserializer;
    }

    /**
     * Initializes a list of agendas.
     */
    public void InitializeAgendas(List<string> files) {
      List<DeserializedAgenda> agendas = this.deserializer.Deserialize(files);

      foreach (DeserializedAgenda agenda_data in agendas) {
        IAgenda agenda = this.initializeAgenda(agenda_data);

        this.container.Add(agenda_data.Name, agenda);

        this.generator.Reset();
      }
    }

    private IAgenda initializeAgenda(DeserializedAgenda agenda_data) {
      // Creates the activity nodes.
      foreach(DeserializedActivity activity in agenda_data.Activities) {
        this.createActivity(activity);
      }

      // Creates the edges to connect nodes.
      foreach (DeserializedActivity activity in agenda_data.Activities) {
        foreach (string adjacent in activity.Adjacents) {
          this.generator.AddEdge(activity.Name, adjacent);
        }
      }

      return generator.GetAgenda();
    }

    private void createActivity(DeserializedActivity activity_data) {
      this.generator.NewActivity(
        activity_data.Name,
        activity_data.Class,
        activity_data.Id,
        activity_data.IsRoot
      );
    }

  }

}
