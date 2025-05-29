var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SendApiWithAspire>("sendapiwithaspire");

builder.Build().Run();
