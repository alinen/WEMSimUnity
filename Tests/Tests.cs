using System;
using System.Collections.Generic;
using Wem.Agenda;
using Wem.Container;
using Wem.Map;
using Wem.Yaml;

namespace Tests {

  class Tests {

    static void Main(string[] args) {

      IContainer container = new Container();
      ContainerInitiazer.Initialize(container);

      string map_file = "/home/gvso/Desktop/WEMSimUnity/Unity/Assets/Scripts/Example/Config/example.map.yml";
      MapInitializer map_initializer =
        (MapInitializer) container.Get("map.initializer");
      map_initializer.Initialize(map_file);

      //Map map = (Map) container.Get("map");
      //Console.Write(map);

      List<string> agenda_files = new List<string> ();
      agenda_files.Add("/home/gvso/Desktop/WEMSimUnity/Unity/Assets/Scripts/Example/Config/Agendas/example.agenda.yml");
      agenda_files.Add("/home/gvso/Desktop/WEMSimUnity/Unity/Assets/Scripts/Example/Config/Agendas/example2.agenda.yml");

      AgendaInitializer agenda_initializer =
        (AgendaInitializer) container.Get("agenda.initializer");
      agenda_initializer.Initialize(agenda_files);

      AgendaContainer agenda_container = (AgendaContainer) container.Get("agenda.container");

      Console.WriteLine(agenda_container.Get("example.agenda"));
      /*Console.WriteLine(agenda_container.Get("example2.agenda"));*/
    }

  }

}
