# MajorProject
 Praxisprojekt zur Realisierung einer Charakter-Modifikation, durch die Programmierung einer unterstützenden App für das Pen & Paper Regelwerk Hell Over Mind mithilfe von Unity.

 Version: 1.0
## 1.Projekt Beschreibung

Das Projekt wurde für das Pen&Paper Regelwerk, „Hell Over Mind" und soll eine Ergänzung zum Charakterbogen darstellen. Außerdem wird durch die App die Erstellung eines Charakters dargestellt. Die Daten, des Charakterbogen, werden extern auf einem Cloud-Server gespeichert.


## 2.Inhalt

1.Das Abstract, mit einem PDF, um eine kleine Zusammenfassung der wissenschaftlichen Arbeit zu geben<br>
2.Der Unity Ordner, mit Assets, der ausführbaren .apk, den verwendeten Packages und den ProjectSettings<br>
3.Die verwendeten PHP Skripte, die auf dem Server liegen<br>
4.Die wissenschaftliche Arbeit, als Pdf <br>
5.Ein Screencast, das als Video die App zeigt und ihre Funktionen<br>
6.Die verwendeten SQL Skripte vom Server<br>


## 3.Reproduktion

Um das Projekt zu kopieren, werden ein paar Schritte nötig sein.<br>
1.Downloaden sie den Unity Ordner<br>
2.Als nächstest öffnen sie das Projekt über Unity und stellen als Zielplattform Android aus<br>
3.Sie haben nun erfolgreich die App und können sie starten<br>
4.Um ihren eigenen Server verbinden zu können, müssen sie jedoch nun folgende Schritte machen<br>
5.Zuerst benötigen sie einen Server mit phpmysqladmin, dort spielen sie die SQL Skripte aus dem Ordner rauf<br>
6.für phpmyadmin, benötigen sie Daten zum anmelden, diese geben sie in allen PHP Skripten unter "$database_username" und "$database_password" an<br>
7.danach müssen die PHP Datein in den var/www/html Ordner von dem Server<br>
8.Der letzte Schritt, ist es die URL bei Unity zu ändern, dazu gehen sie in den den Unity Order und dort auf Assets/Scripts/UtilityScripts/UrlStrings.cs<br>
9.in dieser Datei, ändern sie in den Strings die IP-Adresse zu ihrer IP-Adresse<br>
10.Nun läuft das Projekt auf ihrem Server<br>


## 4.Mitarbeit

Falls sie bei dem Projekt mitarbeiten wollen oder Ideen für weitere Features haben, melden sie sich bei "n.walther@protonmail.com".<br>




