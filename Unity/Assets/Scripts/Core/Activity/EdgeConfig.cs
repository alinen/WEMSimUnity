
namespace Wem.Activity {

  public class EdgeConfig {
    //double probability;

    public IActivity Adjacent;

    public EdgeConfig(IActivity node, double probability) {
      this.Adjacent = node;
      //this.probability = probability;
    }

  }

}
