//https://learn.microsoft.com/en-us/dotnet/aspire/messaging/kafka-component?tabs=dotnet-cli

//var builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<Projects.Producer>("producer");

//builder.AddProject<Projects.Consumer>("consumer");

//builder.Build().Run();

//dotnet add package Aspire.Hosting.Kafka
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var kafka = builder.AddKafka("kafka")
    .WithKafkaUI(kafkaUi => kafkaUi.WithHostPort(8080));

builder.AddProject<Projects.Producer>("producer")
    .WithReference(kafka)
    .WithArgs(kafka.Resource.Name);

builder.AddProject<Projects.Consumer>("consumer")
    .WithReference(kafka)
    .WithArgs(kafka.Resource.Name);

builder.AddKafka("kafka2").WithKafkaUI();

builder.Build().Run();