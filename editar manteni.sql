select CONCAT(serialArt, ' / ', nombreArt) As Nombre 
,d.detm_tipomantenimiento
,d.detm_detalle
,d.detm_costomanoobra
,d.detm_repuestos
,d.detm_numeroexterno
,d.detm_costorepuestos
from detamantenimientos d
 inner join mantenimientos m on d.detm_idmantenimiento = m.mant_id 
 inner join articulo a on d.detm_idarticulo=a.idArt
 where m.mant_id = '2'
 
 
 update detamantenimientos set detm_tipomantenimiento='',detm_detalle='',detm_costomanoobra='',detm_repuestos=''  ,detm_numeroexterno='',detm_costorepuestos='' where detm_idmantenimiento=''