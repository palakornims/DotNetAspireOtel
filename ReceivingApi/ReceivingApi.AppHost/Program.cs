var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ReceivingApi>("receivingapi");

builder.Build().Run();
