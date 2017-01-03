# StoryGraph

StoryGraph is a tool for writers or managers of fictitious / non-existing worlds: a tool that connects and defines relationships between *people*, *locations*, *items*, *groups* and *stories*.

Think of it as a social network for fantasy worlds.

StoryGraph provides an interface for navigating this graph, and adding new nodes to the graph.

## Who is it meant for?

We've thought of these while conjuring up the idea:

- Writers of fiction.
- Game masters in role-playing games.
- Historians who want to model a world that no longer exists - also, genealogists.

## Entities

Entities can be one of the following:

- *A character* (people)
- *A location* (world / continent / country / area / city / building / spot)
- *An item* (literally any item)
- *A group* (organization / company / religious group / conspiracy / etc.)
- *A story* (a text containing references to any of the above)

The definition of an entity is dependent on the entity type, but they all share some common traits:

- A name.
- A description.
- An (in-universe) date they started / were born / were created.
- An (in-universe) date they ended / died / were destroyed.
- A reason for their demise or ending.

## Relationships

Relationships can be defined between two entities, which is really what makes up the graph: these are the links (in the fantasy world, but also literal links) that connect everything together. Along with just the connection, there is also a definition of the type of the relationship. So a relationship with characters on both sides might be *child of*, *spouse*, *lover*, *enemy*, *ally*, etc., while `character -> item` might be *creator of*, *owner of*, etc. The opposite relation is automatically created when appropriate - a father automatically becomes parent of his children.

## Stories

Stories are an entity type, but they are special, in that any mention in the story of any other entity automatically becomes a relationship. 

## Timeline

Since all entities start and end, the universe also have a temporal dimension to supplement the spatial. A timeline can be generated, detailing what happened in what order. The engine is also aware of any inconsistencies that may arise, such as a person being born long after his mothers death.

## So how do I install it?

Well... you don't. This is a project proposal and the foundation for a specification of the system.

## Technical foundation

I am thinking this project would become a REST API, that could serve as a backend for the project.