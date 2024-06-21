# User Manual

Projekt: PuzzlExpress

Teammitglieder: Florian Schmidt, David Zeugner, David Fröschl, Fanni Horvat, Süleyman Tegmen

Dieses Dokument erklärt die grundlegenden Spielmechaniken bzw. die grundlegende Funktionsweise unseres Spiels, inkl. aller Menüpünkte und Optionen.

## Einleitung
PuzzlExpress ist ein Puzzle-Spiel mit Eisenbahn-Setting, das sich vor allem an Kleinkinder richtet. Im Rahmen der Bewältigung der zahlreichen Level lernt der Spiel logisches Denken und Problemlösung - das Spiel ist somit pädagogisch wertvoll.

## Hauptmenü
Nach dem Starten des Spiels landet der Spieler im Hauptmenü. Dort finden sich 4 Buttons:
- Start
    - Bringt den Spieler zum Levelauswahlmenü.
- Shop
    - Bringt den Spieler zum Shop, wo Skins für die Lok ausgewählt werden können
- Options
    - Öffnet das Optionsmenü
- X (oben rechts)
    - beendet das Spiel

## Levelauswahlmenü
Hier findet sich eine Liste aller Level, die es im Spiel gibt. Zu Beginn kann der Spieler nur das erste Level spielen. Erst nach Abschluss eines Levels wird das darauffolgende Level freigeschalten. 

In jedem Level gibt es bis zu 3 Sterne zu sammeln (mehr dazu in der Erklärung der Shops) - diese zu sammeln ist jedoch keine Voraussetzung dafür, dass das nächste Level freigeschalten wird.

## Shop
In jedem Level können bis zu 3 Sterne gesammelt werden. Diese Sterne liegen oftmals nicht auf dem einfachsten Weg, wodurch das Sammeln aller Sterne eine zusätzliche Herausforderung für den Spieler darstellt. Bei bestimmten Anzahlen an gesammelten Sternen schaltet der Spieler neue Skins für die Lok frei. Im Shop kann eingesehen werden, wie viele Sterne für welchen Skins benötigt werden und - wenn der Skin bereits freigeschalten wurde - kann er hier ausgewählt werden.

## Optionsmenü
Im Optionsmenü können verschiedene Einstellungen getroffen werden, damit der Spieler das Spielerlebnis nach seinen eigenen Anforderungen anpassen kann.
- Mithilfe eines Lautstärkereglers kann die Lautstärke des Spiels eingestellt
- Ein Dropdown Menü ermöglicht die Auswahl der Bildschirmauflösung
- Mithilfe einer Checkbox kann zwischen Vollbild- und Fenstermodus gewechselt werden
- Die Geschwindigkeit, mit der sich der Zug bewegen soll, kann eingestellt werden
- Der Spielstand kann zurückgesetzt werden (freigeschaltene Level werden zurückgesetzt, gesammelte Sterne gelöscht)

## Spiel

### Tutorial
In den ersten Leveln des Spiels führt ein Tutorial den Spieler in das Spiel ein. Sämtliche Spielmechaniken (Schienen, Hindernisse, etc.) werden ausführlich erklärt und anhand von Beispielen präsentiert. Nach dem Absolvieren des Tutorials werden die Level immer herausfordernder, um den Spieler stets vor neue Herausforderungen zu stellen.

### Grundmechanik
Das Ziel des Spiels ist es, den Zug von seinem Startpunkt aus zum Zielbahnhof zu bringen. Dazu muss es einen durchgehenden Schienenweg vom Ausgangspunkt zum Zielbahnhof geben - standardmäßig ist dieser jedoch nicht vorhanden. (Schienen sind falsch rotiert, Weichen sind falsch gestellt, Hindernisse blockieren die Schienen, ...)

Der Spieler muss nun einen passierbaren Weg für den Zug herstellen. Dazu hat er folgende Möglichkeiten:
- Klick auf eine Schiene/Kurve
    - rotiert die Schiene
- Klick auf eine Weiche
    - stellt die Weiche um
- Klick auf ein Hindernis
    - beseitigt das Hindernis

Sobald der Spieler der Meinung ist, einen passierbaren Schienenweg hergestellt zu haben, kann er den Zug losfahren lassen, indem er ihn anklickt. Hat sich der Spieler geirrt und der Zug kommt nicht erfolgreich am Zielbahnhof an (kommt von der Strecke ab, kollidiert mit einem Objekt, ...) geht der Spieler Game Over und muss das Level erneut versuchen. Erreicht der Zug erfolgreich den Zielbahnhof ist das Level geschafft und der Spieler kann mit dem nächsten Level fortfahren.

### Sterne
In jedem Level kann der Spieler bis zu 3 Sterne einsammeln. Häufig gibt es mehrere Möglichkeiten, wie ein Level gelöst werden kann: Wählt der Spieler die einfachste Route erhält er in der Regel nicht alle 3 Sterne. Das Sammeln aller Sterne ist also eine zusätzliche Option für Spieler, die eine größere Herausfoderung suchen. 
Als Belohnung für das Sammeln von vielen Sternen schaltet der Spieler zusätzliche Skins für die Lok frei (siehe Erklärung zum Optionsmenü).

### Pause
Durch Drücken der Esc-Taste oder Klick auf den Pause-Button rechts oben kann das Spiel jederzeit pausiert werden. Im Optionsmenü hat der Spieler folgenden Möglichkeiten:
- Level neu starten
- Zum Hauptmenü zurückkehren
- Spiel beenden
- Zum Levelauswahlmenü zurückkehren
- Spiel fortsetzen

Das Spiel kann durch Klicken auf "Spiel fortsetzen" oder nochmaliges Drücken der Esc-Taste wieder fortgesetzt werden.

<hr>

# Deployment Manual

Projekt: PuzzlExpress

Teammitglieder: Florian Schmidt, David Zeugner, David Fröschl, Fanni Horvat, Süleyman Tegmen

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

<hr>

## Architectural Description

Projekt: PuzzlExpress

Teammitglieder: Florian Schmidt, David Zeugner, David Fröschl, Fanni Horvat, Süleyman Tegmen

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
Die Projektstruktur in Unity ist klar organisiert, um die Übersichtlichkeit und Wartbarkeit des Projekts zu gewährleisten:

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
