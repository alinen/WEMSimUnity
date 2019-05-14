using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Wem.Yaml {

  abstract public class Deserializer {

    /**
     * The YAML deserializer.
     */
    protected YamlDotNet.Serialization.Deserializer deserializer;

    /**
     * Deserializer constructor.
     */
    public Deserializer() {
      this.deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
    }

  }

}
