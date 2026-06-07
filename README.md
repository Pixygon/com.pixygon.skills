# Pixygon — Skills

Stats, stat-modifiers, skills, and the combat data types (damage, ailments,
weapons). Originally shaped around the twin-stick-shooter (Dreadwager); the stat
vocabulary is being generalized into the shared `com.pixygon.stats` catalog.

## Overview

A **skill** (`SkillData`) applies **stat modifiers** (`StatMultiplier` /
`StatAddition`) to a character's stats, identified by the `StatNames` enum.
`SkillManager` rolls skills (e.g. the level-up choices).

## Key types

| Type | What it is |
|---|---|
| **`SkillData`** | A skill: a set of `StatMultiplier` / `StatAddition` modifiers (+ presentation). |
| **`StatNames`** | Enum of stats (projectile/reload/fire-rate/helper/… — shooter-centric). |
| **`StatMultiplier` / `StatAddition`** | Percent / flat stat modifiers. |
| **`StatData`** | `value` + `title` + `description`. |
| **`DamageType`** | `Normal, Fire, Earth, Water, Air, Aether, Summon` — the canonical element list. |
| **`Ailments`** | `Burn, Daze, Freeze, Zap, …`. |
| **`SpecialSkills`** | Enum of authored special abilities. |
| **`SkillManager`** | Rolls / scrambles the skill choices. |
| **`CharacterData`** | Thin base-stats SO (hp/speed/damage/magic/…). |
| **`BulletData` / `GunData`** | Shooter weapon + projectile data. |

## Dependencies

None declared (uses `idsystem` conventions via the consuming game).

## Usage

```csharp
foreach (var add in skill._additions) stats.Apply(add);
```

## Status

`0.5.0`. **Migration in progress → `com.pixygon.stats`:** the big extensible stat
catalog (`StatDefinition` / `StatBlock`) supersedes `StatNames`. Plan: add a
`StatNames → StatDefinition` bridge that **preserves each enum value's integer** so
live Dreadwager saves/skill assets don't drift (additive; Dreadwager keeps working).
`DamageType` stays the canonical element set. **Known bug:** never use `{x:P}` in
`StatMultiplier.Description` — `CurrentCulture.PercentSymbol` renders as a square in
IL2CPP/Mono builds; use `Mathf.RoundToInt(v*100)+"%"`.
