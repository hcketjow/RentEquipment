# Uczelniana wypożyczalnia sprzętu

## Opis projektu

Aplikacja konsolowa w C#, która umożliwia zarządzanie wypożyczalnią sprzętu.

System pozwala:

* dodawać użytkowników i sprzęt,
* wypożyczać i zwracać sprzęt,
* sprawdzać dostępność,
* naliczać kary za opóźnienia,
* generować raport.

---

## Struktura

Projekt podzielony jest na trzy części:

* **Model** – klasy: `Equipment`, `Laptop`, `Camera`, `Projector`, `User`, `Student`, `Employee`, `Rent`
* **Logika** – `RentalManagement` (obsługa wypożyczeń, zwrotów, reguł)
* **Program** – `Program.cs` (uruchomienie i działanie)

---

## Reguły biznesowe

* Student: max. 2 wypożyczenia
* Pracownik: max. 5 wypożyczeń
* Niedostępny sprzęt nie może być wypożyczony
* Kara: 10 zł za dzień opóźnienia

---

## Decyzje projektowe

* Każda klasa ma jedną odpowiedzialność (np. `Rent` – wypożyczenie, `Equipment` – sprzęt)
* Logika biznesowa jest w jednej klasie (`RentalManagement`)
* `Program.cs` tylko pokazuje działanie systemu
* Dziedziczenie użyte tylko tam, gdzie ma sens (`User`, `Equipment`)
---

## Uruchomienie

```
git clone <repozytorium>
```
```
cd RentEquipment
```
```
dotnet run
```

---

## Scenariusz

Program pokazuje:

* dodanie danych,
* poprawne i błędne wypożyczenia,
* przekroczenie limitu,
* zwrot w terminie i po terminie,
* podsumowanie końcowe.
