# Loki
The 2nd mightiest in Asgard

### What is this?

Loki is a tiny little app that can intercept URI's being created and can manipulate them.
You can create a config that will autorespond with messages for a specific url.

### [Loki in action](https://youtu.be/ptoRrPg_Khc)

### Features

- Spoofs methods that try to check the calling/entry assembly
- Uses a `HttpListener` to spoof the replies locally
- Configuration via JSON
- Command line GUI

### Usage

Either drag&drop the config file on `Loki.exe` or manually select `Start!` from the main menu

### How?

Loki uses Harmony to hook the `CreateThis` method in `System.Uri` and if needed, changes it to point to `localhost`.
