## Architectural Description

Projekt: PuzzlExpress

Teammitglieder: Florian Schmidt, David Zeugner, David Fröschl, Fanni Horvath, Süleyman Tegmen

Dieses Dokument beschreibt die Architektur des Projekts, das mit Unity und C# entwickelt wurde. Das Projekt integriert verschiedene externe Programme zur Erstellung von Assets und nutzt Unity zur Implementierung und Verwaltung dieser Assets in einer strukturierten Umgebung.

## Komponenten

### Unity mit C#

Unity dient als Grundgerüst für das gesamte Projekt. Die Entwicklung erfolgt mit C#, das die Skripterstellung und Logik für die GameObjects ermöglicht. Die wichtigsten Komponenten innerhalb von Unity sind:

- Szenen: Verschiedene Umgebungen oder Levels im Spiel, die jeweils eine eigene Sammlung von GameObjects und Skripten enthalten.
- GameObjects: Die grundlegenden Bausteine der Szene, die durch Skripte gesteuert werden.
- Skripte: C#-Skripte, die das Verhalten von GameObjects definieren und steuern

### Unity Version Control

Für die Kollaboration und Verwaltung des Projektcodes verwenden wir Unity Version Control. Dies ermöglicht die Nachverfolgung von Änderungen, Zusammenarbeit im Team und das einfache Zurücksetzen auf frühere Versionen des Projekts.

### Externe Programme

Wir haben verschiedene exterene Programme zur Erstellung von Assets verwendet, die dann in Unity integriert werden:

- Photoshop: Zur Erstellung und Bearbeitung von 2D-Grafiken und Texturen.
- GIMP: Eine freie Alternative zu Photoshop, die wir ebenfalls zur Bearbeitung von 2D-Grafiken verwendet haben.
- Figma: Für die Erstellung von UI-Designs, die wir dann in das Spiel integriert haben.
- Audacity: Zur Aufnahme und Bearbeitung von Audio, wie Soundeffekten und Musik.

## Implementierung der Assets in Unity

Die mit den externen Programmen erstellten Assets werden in Unity importiert und wie folgt verwendet:

- 2D-Grafiken und Texturen: Diese werden als Sprites oder Materialien für die GameObjects verwendet.
- UI-Designs: Die in Figma entworfenen Benutzeroberflächen werden in Unity nachgebaut und angepasst.
- Audio: Die mit Audacity bearbeiteten Audiodateien werden in Unity als AudioClips importiert und verschiedenen GameObjects zugewiesen.

## Projektstruktur in Unity

Wir haben eine klare Ordnerstruktur in Unity implementiert, um für Übersichtlichkeit zu sorgen und die Wartbarkeit des Projekts zu gewährleisten:

- Assets: Der Hauptordner für alle importierten und erstellten Assets.
  - Scenes: Enthält alle Szenendateien des Projekts
    - Level: Unterordner, der die Szenen für die einzelnen Level enthält
  - Scripts: Alle C#-Skripte, die das Verhalten der GameObjects steuern.
  - Animations: Enthält alle Animationsdateien, die für die Animationen der GameObjects verwendet werden.
  - Buildings: Grafiken für Gebäude im Spiel.
  - Loks: Lokomotiven-Assets
  - People: Charaktermodelle und -texturen, die im Spiel verwendet werden.
  - PlantsNfriends: Assets für Pflanzen und andere Natur- bzw. Umgebungsobjekte.
  - Roads: Grafiken für Straßen und Wege.
  - Sounds: Alle Audiodateien, die im Projekt verwendet werden.
  - Sprites: 2D-Grafiken und Texturen, die im Spiel verwendet werden (alle restlichen Grafiken, die in keine der anderen Kategorien gepasst haben)
  - TextMesh Pro: Schriften und Text-Assets, die mit TextMesh Pro erstellt wurden.
  - Tracks: 2D Grafiken und Texturen der Schienen
  - UI: UI-spezifische Assets und Prefabs.
- Prefabs: Vordefinierte GameObjects, die mehrfach in verschiedenen Szenen verwendet werden können.
- Resources: Assets, die zur Laufzeit geladen werden können.
- Plugins: Drittanbieter-Plugins, die im Projekt verwendet werden.
