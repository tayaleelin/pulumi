using Pulumi;
using Pulumi.AzureAD;
using Pulumi.Azure.ContainerService;
using Pulumi.Azure.ContainerService.Inputs;
using Pulumi.Azure.Core;
using Pulumi.Azure.Network;
using Pulumi.Azure.Authorization;
using Pulumi.Random;
using Pulumi.Tls;

class AksStack : Stack
{
  public AksStack()
  {
    var config = new Pulumi.Config();
    var kubernetesVersion = config.Get("kubernetesVersion") ?? "1.19.1";

    var resourceGroup = new ResourceGroup("aks");

    var password = new RandomPassword("password", new RandomPasswordArgs
    {
      Length = 20,
    }).Result;

    var sshPublicKey = new PrivateKey("ssh-key", new PrivateKeyArgs
    {
      Algorithm = "RSA",
      RsaBits = 4096,
    }).PublicKeyOpenssh;


  }
}