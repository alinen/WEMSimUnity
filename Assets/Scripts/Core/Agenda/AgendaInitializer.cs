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
     *
     * @param List<string> files
     *   List of paths to YAML files.
     */
    public void InitializeAgendas(List<string> files) {
      List<DeserializedAgenda> agendas = this.deserializer.Deserialize(files);

      foreach (DeserializedAgenda agenda_data in agendas) {
        // Starts a new Agenda.
        this.generator.Start(agenda_data.Id);

        IAgenda agenda = this.initializeAgenda(agenda_data);

        // Saves the generated agenda in the container.
        this.container.Add(agenda_data.Id, agenda);
      }
    }

    /**
     * Initializes a single agenda.
     *
     * @param Wem.Yaml.DeserializedAgenda agenda_data
     *   The data to initialize new agenda.
     */
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

      return this.generator.GetAgenda();
    }

    /**
     * Creates a new activity.
     *
     * @param Wem.Yaml.DeserializedActivity activity_data
     *   The data to create new activity.
     */
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
