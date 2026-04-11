## Bloque 1 — Catálogos sin FK (empieza aquí)
Estas no dependen de nadie, puedes hacerlas en cualquier orden entre ellas:

.


## Bloque 2 — Entidades núcleo





## Bloque 3 — Perfiles
.




## Bloque 4 — Documentos
.




## Bloque 5 — Negocio core
.







## Bloque 6 — Comercio
.


## Bloque 7 — Social
.

audit_log              → depende de persons


## Bloque 8 — Analítica
.
price_history          → depende de citiesormunicipalities, type_vehicles, type_load
city_pricing_rules     → depende de citiesormunicipalities
return_load_suggestions → depende de drivers, loads
