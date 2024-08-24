using Producer;
using Confluent.Kafka;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKafkaProducer<string, string>("kafka");
builder.AddKafkaProducer<Null, string>("kafka");

builder.Services.AddHostedService<IntermittentProducerWorker>();
builder.Services.AddHostedService<ContinuousProducerWorker>();

builder.Build().Run();