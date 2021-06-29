using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

class MyStack : Stack
{
  public MyStack()
  {
    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup("resourceGroup");

    // Create an Azure Storage Account
    var storageAccount = new Account("storage", new AccountArgs
    {
      ResourceGroupName = resourceGroup.Name,
      AccountReplicationType = "LRS",
      AccountTier = "Standard",
      Tags =
            {
                { "Environment", "Dev" }
            }
    });

    this.ConnectionString = storageAccount.PrimaryConnectionString;
    // Export the connection string for the storage account

  }

  [Output]
  public Output<string> ConnectionString { get; set; }
}