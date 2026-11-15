Notes for implementers:

- Primary keys:
    - Have the `[Key]` attribute if simple.
    - Are the set of XyIds for many-to-many tables.
    - Are noted in a comment otherwise (e.g., composite keys).
- Conventions:
    - Many-to-many link models have four values: XyId, Xy, AbId, Ab. Any table fitting this format is a many-to-many
      link model unless otherwise noted in the model.
    - Navigation properties are nullable even when the navigation ID is not so that some optimizations can be made (like
      not having to load linked items that weren't requested). Likewise, collection navigations are nullable so the
      difference between "no results" and "not loaded" is differentiable (potentially - implementations may differ).
    - Many-to-many links are not linked back to from the models they link. Instead, those models link directly to each
      other using collections.
    - Collection navigation properties are `ICollection<...>` unless there's a reason to be something else.
    - For models with only an ID and a single required field (and maybe some optional fields that wouldn't be expected
      to be used in differentiation), the required field should be treated as being unique unless otherwise noted.

FAQ
-----
Q: Why not use data annotations?
A: While some would be useful to use, others - like `[PrimaryKey(...)]` when declaring a composite key - would require
importing additional libraries (`PrimaryKeyAttribute` comes from EF Core). It was decided that rather than partial use
or importing otherwise-unnecessary libraries, annotations would not be used and important details would be defined here
or in comments on the models. This decision *may* change in the future and data annotations *may* be added later.

Potential TODO List:
-----

- Find way to represent these as attributes without importing EF:
    - Composite primary key
    - Unique
