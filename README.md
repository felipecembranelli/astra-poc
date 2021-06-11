![alt tag](https://github.com/felipecembranelli/astra-poc/blob/master/doc/datastax.png)


# Getting Started with Apache Cassandra™ and C# using DataStax Astra 
This web application is a demo using astra-csharp client library.

# Config

You need to set up your astra database connection. Check out the [Astra documentation](https://docs.datastax.com/en/astra/docs/)

Once you generate your connection bundle file and your keys, configure it as environment variables in you box:

```sh
export BundlePath="my-bundle-file.zip"
export Username="CLIENT_ID"
export Password="CLIENT_SECRET"

```

These variables will be used in the code (Repository/AstraRepository.cs):

```dotnet
// Fill in these constants with your database credentials and bundle path
private string BundlePath = Environment.GetEnvironmentVariable("BundlePath");
private string Username = Environment.GetEnvironmentVariable("Username");
private string Password = Environment.GetEnvironmentVariable("Password");
```



# Usage

```sh
cd astra-client-web-console
dotnet run
```

# Sample Screens

![alt tag](https://github.com/felipecembranelli/astra-poc/blob/master/doc/mainpage.png)


