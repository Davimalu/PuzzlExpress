# Deployment Manual

Projekt: PuzzlExpress

Teammitglieder: Florian Schmidt, David Zeugner, David Fröschl, Fanni Horvath, Süleyman Tegmen

Dieses Dokument enthält alle Schritte, die notwendig, um das fertige Spiel auszuführen bzw. den SourceCode mithilfe des Unity Editors zu öffnen und das Spiel anschließend für eine bestimmte Plattform zu exportieren.

## Ausführen des fertigen Spiels

Das Ausführen des fertigen Spiels ist äußerst einfach, da im Rahmen des "Buildens" in Unity sämtliche Dependencies verpackt und gemeinsam mit dem fertigen Spiel ausgeliefert werden. Die für das Spie benötigte Mono-Runtime wird gemeinsam mit dem Spiel ausgeliefert. Steht auf dem System des Spielers kein DirectX zur Verfügung wird das Spiel automatisch mit OpenGL gestartet.

Der Enduser muss daher nur das Spiel herunterladen und die Datei "PuzzlExpress.exe" öffnen, um das Spiel zu starten. Es sind keine weiteren Schritte notwendig.

Wir haben sowohl eine Version für Windows als auch eine Version für Linux zur Verfügung gestellt. Da niemand von uns einen Mac besitzt, konnten wir leider keine Mac-Version zur Verfügung stellen.

## Öffnen des Projekts im Unity Editor

### Unity

Um das Projekt in Unity zu öffnen, muss zunächst der Unity Editor installiert werden:

- Download des Unity Launchers von www.unity.com
- Öffnen des Unity Launchers und Download der entsprechenden Editor Version

Wir verwenden für unser Projekt die LTS-Version 2022.3.21f1 - es ist daher darauf zu achten, dass exakt diese Version von Unity installiert wird.

Um nun das Projekt zu öffnen muss rechts oben im Launche der "Add"-Button geklickt werden. Anschließend muss das Projektverzeichnis ausgewählt werden: Das Projekt sollte nun im Unity Launcher erscheinen. Durch Klick auf das Projekt öffnet sich der Unity Editor und lädt unser Projekt.

### IDE

Der Unity Editor selbst kann nur Game Objects, Szenen, etc., allerdings keinen Code anzeigen. Um effektiv mit Unity arbeiten zu können (bzw. Einsicht in den Quellcode nehmen zu können) ist daher ein externes IDE notwendig, das mit C# Code umgehen kann. Wir empfehlen VS Code, jedoch kann bspw. auch Microsoft Visual Studio verwendt werden.
In den Einstellungen des Unity Editors kann der Nutzer auswählen, welches der installierten IDEs er verwenden möchte. Ein Klick auf ein Script im Unity Editor öffnet anschließend den Code im ausgewähten IDE.

### Plastic SCM

Wir haben für dieses Projekt Unity Version Control anstelle von Git verwendet, da es besser mit der Unity Engine integriert ist. Prinzipiell sollte Unity Version Control in den Unity Editor integriert sein und im Editor als Option aufscheinen. Im Rahmen des Projekts hat dies bei einigen Teammitgliedern jedoch nicht einwandfrei funktioniert, weshalb wir auf ein externes Programm zurückgegriffen haben, um unsere Commits zu verwalten. Dieses kann auf www.plasticscm.com heruntergeladen werden, ist für die Inbetriebnahme des Projekts jedoch nicht notwendig.

## Builden des Projekts im Unity Editor

Ist das Projekt im Unity Editor geöffnet kann es folgendermaßen zu einem eigenständigen Executable gebuilded werden:

- Klick auf "File" in der Navigationsleiste von Unity
- Klick auf "Build Settings"

Es öffnet sich ein Fenster, das es ermöglicht, einige Einstellungen zum Build zu treffen. Ganz oben muss ausgewählt werden, welche Szenen (einzelne Menüs, einzelne Level) im Build inkludiert werden sollen: Hier müssen alle Szenen ausgewählt werden.

In der unteren Hälfte des Fensters kann ausgewählt werden für welche Plattform das Spiel gebuilded werden soll. Unity untersützt unzählige Plattformen, wir haben unser Spiel jedoch ausschließlich für PCs optimiert (auf Touchscreen-basierten Systemen wie Handys/Tablets würde es nicht korrekt funktionieren), daher sollte entweder Windows oder Linux ausgewählt werden.

Nach dem Klick auf "Build" wird der User nach einem Dateinahmen und Speicherort für das fertige Spiel gefragt. Nachdem diese Informationen bereitgestellt wurden beginnt Unity mit dem Builden des Projekts - dies kann einige Minuten dauern.
