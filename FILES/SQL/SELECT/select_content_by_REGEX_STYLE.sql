SELECT * FROM gb_rifoms.cms_content
where (category_id=8 or category_id=9)  and 
content regexp '<p style="[[:alnum:][:digit:][:space:];,:\(\)\'\-\.]+"'