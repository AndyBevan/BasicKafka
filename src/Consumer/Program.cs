using Confluent.Kafka;
using Consumer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKafkaConsumer<Ignore, string>("kafka");

builder.Services.AddHostedService<ConsumerWorker>();

builder.Build().Run();