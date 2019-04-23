using Wem.Agenda;
using Wem.Container;
using Wem.Yaml;

namespace Wem.Map {

  public class MapInitializer {

    /**
     * The simulation map.
     */
    protected IMap map;

    /**
     * The container of agendas.
     */
    protected AgendaContainer agendas;

    /**
     * The YAML file deserializer for the map.
     */
    protected MapDeserializer deserializer;

    public static MapInitializer create(IContainer container) {
      return new MapInitializer(
        (Map) container.Get("map"),
        (AgendaContainer) container.Get("agenda.container"),
        (MapDeserializer) container.Get("yaml.map.deserializer")
      );
    }

    /**
     * MapInitializer constructor.
     *
     * @param Wem.Agenda.AgendaContainer agendas
     *   The container of agendas.
     * @param Wem.Yaml.MapDeserializer deserializer
     *   The map deserializer.
     */
    public MapInitializer(IMap map,
                          AgendaContainer agendas,
                          MapDeserializer deserializer) {

      this.map = map;
      this.agendas = agendas;
      this.deserializer = deserializer;
    }

    /**
     * Initializes the simulation maps.
     *
     * @param string path
     *   Path to YAML file of the map.
     */
    public void Initialize(string path) {
      // Deserializes the map file.
      DeserializedMap des_map = this.deserializer.Deserialize(path);

      this.map.Id = des_map.Id;

      foreach (DeserializedArea deserialized_area in des_map.Areas) {
        Area area = new Area(deserialized_area);

        this.map.Areas.Add(area);
      }
    }

  }

}
