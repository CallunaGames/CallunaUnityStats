# UnityPackageTemplate
Template for new unity packages

## Glossary
- **Stat**: A stat value that can be modified by various influences. An example stat is "Strength" of an RPG. Strength can for example be influenced by equipment, temporary buffs or the environment
- **StatDefinition**: Defines the default formula of a stat by holding a list of PipelineLayerDefinitions.
- **StatsCollection**: A collection of different stat values. There can be different collections for different agents in the game e.g. Player character and different enemy types.
- **StatValueDefinition**: Defines a specific stat value in a collection with base value.
- **StatId**": Id of a specific stat like "Strength" or "Dexterity"
- **PipelineLayer**: A layer in the stat calculation pipeline.
- **PipelineLayerDefinition**: Defines how a layer is calculated.
- **SimplePipelineLayerDefinition**: A pipeline layer that has no modifer values
- **PipelineLayerWithValuesDefinition**: A pipeline layer that accepts modifier values
- **ModifierValue**: A value of a PipelineLayerWithValues
- **StatChange**: Defines a change to a specific stat using ModifierValues