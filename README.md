# n3ttl3t Says

## A pattern memory game

The classic handheld flashing lights reimagined for touch screens.
Initially a minimalist game but really the MVP for a series of interactive poems.

Please see the [approach](APPROACH.md) for details of my development process.

## Gameplay

The original game was restricted to playing with fixed buttons made of plastic:

![original_gameplay](wip/OriginalGameplay.png)

There was no win state, the length of the longest sequence you remembered was your high score.

Taking inspriration from this but with the flexibility of being able to display anything:

![new gameplay](wip/NewGameplay.png)

Again the win state will just be a highscore, but with this version the higher your score the more vibrant and dynamic the visual effects could get.

## User Stories

```
As a player,
so I can exercise my memory,
I want to be presented with growing sequences of gestures for me to copy
```

```
As a player,
so I can be visually entertained,
I want my gestures to trigger drawing effects (colours, shapes).
```

```
As a player,
so I can challenge myself,
I want to be able to see my highscore
```

```
As the developer,
so I can design gestures easily,
I want a way to record my own and compare input to them
```

```
As the developer,
so I can extend or reuse these features in the future,
I want everything to be TDD'd and robust
```

## Spec

### Terminology:
- A turn: one short unit of time for making gestures, either the game's or the player's.
- A round: two turns, the game's and the player's.
- A sequence: a collection of turns. The length of this collection is the score.

---

## Extension

This is a game on it's own, but also the mechanical basis for a series of art pieces as games. How they will differ:
- The sequences will be of a fixed length each.
- The tempo of each sequence will be determined by the art already made.
- The gestures in each round will be designed over the art.
- The gestures will be designed as less or more difficult by their length, ergonomics(placement, divisions and directions) and speed.
- Difficulty will also be determined by how precise the player's position and timing of there gestures must be.
- The player's turns will animate the audiovisual elements of the interactive poem, if played correctly.