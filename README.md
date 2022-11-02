# Tower Evolution

## Over
---
### In deze tower defense game moet je torens kopen en upgraden om te voorkomen dat de vijanden het einde bereiken.
### Je start met oude torens, maar naarmate je ze upgradet worden ze steeds moderner en sterker.
### Maar de vijanden worden dat ook, dus speel tactisch en probeer het zo lang mogelijk uit te houden.

## Mechanics
---
### Er zijn verschillende mechanics in deze game. Het spawnsysteem van de vijanden is waarschijnlijk de grootste. 

## Wat ik heb geleerd
---

### [Trello](https://trello.com/b/txKUaVVr/tower-defense-tower-evolution)

---

### Een flowchart van het spawnsysteem van de vijanden:
```mermaid
flowchart TB

start((Start))-->calculatePoolSize(Calculate object pool size)
calculatePoolSize-->fillPool{Is the pool filled?}
    fillPool-- Yes -->enemiesActive{Are there enough enemies\nactive in the game?}
        enemiesActive-- Yes -->doNothing{{Do nothing until all enemies are inactive}}
        enemiesActive-- No -->findEnemy(Find an inactive enemy in the object pool)
            findEnemy-- Wait until the spawn interval is over -->enemyActive(Set the found enemy active in the game)
            enemyActive-->enemiesActive
    fillPool-- No -->instantiate(Instantiate enemy)
        instantiate-->fillPool
```

---

##### Mitchel Klijn