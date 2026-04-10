## Bloque 1 — Catálogos sin FK (empieza aquí)
Estas no dependen de nadie, puedes hacerlas en cualquier orden entre ellas:

.
type_documents
document_category
documents_status
type_vehicles
vehicules_status
type_load
roles
person_status
companies_status
relation_type
payment_statuses
payment_providers
transaction_types
status_bids
status_chat
notification_type
message_type
subscription_type
subscription_status
reason_disputes
disputes_status
assignment_role
plans

## Bloque 2 — Entidades núcleo

persons                → depende de person_status, citiesormunicipalities, type_documents
transport_companies    → depende de citiesormunicipalities, companies_status
vehicles               → depende de type_vehicles, vehicules_status
auth_credentials       → depende de persons
auth_sessions          → depende de persons
credit_wallet          → depende de persons, transport_companies

## Bloque 3 — Perfiles
.
drivers                → depende de persons
customers              → depende de persons
person_roles           → depende de persons, roles
person_transport       → depende de persons, transport_companies, relation_type
company_vehicles       → depende de transport_companies, vehicles
company_documents      → depende de transport_companies, type_documents, documents_status

## Bloque 4 — Documentos
.
documents_drivers      → depende de drivers, type_documents, documents_status
documents_vehicles     → depende de vehicles, type_documents, documents_status
documents_customers    → depende de customers, type_documents, documents_status
drivers_vehicles       → depende de drivers, vehicles

## Bloque 5 — Negocio core
.
loads                  → depende de customers, type_load, citiesormunicipalities
load_details           → depende de loads
load_images            → depende de loads
load_status_history    → depende de loads
bids                   → depende de loads, drivers, vehicles, status_bids
trips                  → depende de loads, bids
travel_scale           → depende de trips, citiesormunicipalities
trip_status_history    → depende de trips
trip_assignments       → depende de trips, persons, assignment_role


## Bloque 6 — Comercio
.
payments               → depende de credit_wallet, payment_providers, payment_statuses
credit_transactions    → depende de credit_wallet, transaction_types
person_plans           → depende de persons, plans, payments
subscriptions          → depende de persons, subscription_type, subscription_status, payments


## Bloque 7 — Social
.
ratings                → depende de trips, persons
chat_rooms             → depende de loads, trips, status_chat
chat_participants      → depende de chat_rooms, persons
chat_messages          → depende de chat_rooms, persons, message_type
notifications          → depende de persons, notification_type
disputes               → depende de trips, persons, reason_disputes, disputes_status
audit_log              → depende de persons


## Bloque 8 — Analítica
.
price_history          → depende de citiesormunicipalities, type_vehicles, type_load
city_pricing_rules     → depende de citiesormunicipalities
return_load_suggestions → depende de drivers, loads
