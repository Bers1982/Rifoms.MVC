SELECT * FROM gb_rifoms.cms_content
where comments in(0,1)
and category_id in (8,9)
-- and description is null
order by id desc