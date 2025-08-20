UPDATE gb_rifoms.cms_content
SET description = REGEXP_REPLACE(description, ' style="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
description regexp 'style="[\\d\\D]*?"'; 

UPDATE gb_rifoms.cms_content
SET description = REGEXP_REPLACE(description, ' class="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
description regexp 'class="[\\d\\D]*?"';

UPDATE gb_rifoms.cms_content
set description=replace(description,'</strong>','');

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, '</span></p><p><span>' ,'')
where (category_id=8 or category_id=9)  and 
content regexp '</span></p><p><span>';

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, ' style="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
content regexp 'style="[\\d\\D]*?"';

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, ' class="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
content regexp 'class="[\\d\\D]*?"'; 

UPDATE gb_rifoms.cms_content
SET description = REGEXP_REPLACE(description, ' style="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
description regexp 'style="[\\d\\D]*?"'; 

UPDATE gb_rifoms.cms_content
SET description = REGEXP_REPLACE(description, ' class="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
description regexp 'class="[\\d\\D]*?"';

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, '</span></p><p><span>' ,'')
where (category_id=8 or category_id=9)  and 
content regexp '</span></p><p><span>';

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, ' style="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
content regexp 'style="[\\d\\D]*?"';

UPDATE gb_rifoms.cms_content
SET content = REGEXP_REPLACE(content, ' class="[\\d\\D]*?"' ,'')
where (category_id=8 or category_id=9 or category_id=1)  and 
content regexp 'class="[\\d\\D]*?"';   

UPDATE gb_rifoms.cms_content
SET content=replace(content,'<strong>Директор ТФОМС Республики Ингушетия Дзейтов Магомед Алиевич Приемная</strong>',
'Директор ТФОМС Республики Ингушетия Дзейтов Магомед Алиевич Приемная')
WHERE id=2;

UPDATE gb_rifoms.cms_content
SET content = '<p>Директор ТФ ОМС РИ — Дзейтов Магомед Алиевич,<br>приемные дни: вторник — четверг, часы приема: с 14.00- 16.00<br>контактный телефон: 
<a class=\"fw-bold text-decoration-none\" href=\"tel:88734724141\">8 (8734) 72-41-41 </a> доб. 102 <br><br>Заместитель директора ТФ ОМС РИ — Майсигов Магомед Малсагович<br>
Приемные дни: понедельник  — пятница, часы приема: с 15.00-17.00<br>контактный телефон: <a class=\"fw-bold text-decoration-none\" href=\"tel:88734724141\">8 (8734) 72-41-41</a> 
доб. 103<br><br>Заместитель директора ТФ ОМС РИ — Тимурзиев Руслан Иссакович<br>Приемные дни: среда — пятница, часы приема: с 15.00-17.00<br>контактный телефон: 
<a class=\"fw-bold text-decoration-none\" href=\"tel:88734724141\">8 (8734) 72-41-41</a> доб. 105</p>' 
WHERE (id = '5');

