INSERT INTO `cms_content`
(`category_id`,
`user_id`,
`pubdate`,
`enddate`,
`is_end`,
`meta_desc`,
`meta_keys`,
`ordering`,
`is_arhive`,
`seolink`,
`pagetitle`,
`url`,
`title`,
`description`,
`content`)
VALUES(1,
1,'1001-01-01 01:01:00','1001-01-01','0','Проверить полис','Проверка полиса','1','0','servis-dlya-proverki-aktualnosti-polis','','','Сервис для проверки актуальности полиса','','<div id="modalLoadPolis" class="modal" tabindex="-1">
				<div class="modal-dialog modal-sm modal-dialog-centered ">
					<div class="modal-content">
						<div class="modal-header">
							<h3 class="modal-title">Загрузка из ТФОМС РИ...</h3>
                        </div>
						<div class="modal-body text-center">
							<img src="/images/web/spinner_green_32.gif" />
						</div>
                    </div>
				</div>	
			</div>
	<div id="newSearch" style="display:block;">
    <div id="fio">
        <a class="btn btn-primary my-3 w-100" data-bs-toggle="collapse" data-bs-target="#collapseFio" aria-expanded="false" aria-controls="collapseExample">
            <div id="btnFio" class="float-start d-inline-block text-nowrap">
                <img src="/images/web/enp_site.png" /> Проверить актуальность полиса по ФИО и дате роджения
            </div>
        </a>

        <div class="collapse" id="collapseFio">
            <div class="card card-body border-1 border-primary">
                <form id="SearchFio" method="post">
                    <div class="form-group row">
                        <div class="col-12 mt-3">
                            <label>
                                Для поиска полиса необходимо заполнить <strong>фамилию, имя, отчество и дату рождения</strong>
                            </label>
                        </div>
                        <div class="col-6 mt-3">
                            <label>Фамилия</label>
                            <input type="text" name="FAM" placeholder="Фамилия" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Имя</label>
                            <input type="text" name="IM" placeholder="Имя" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Отчество</label>
                            <input type="text" name="OT" placeholder="Отчество" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Дата рождения</label>
                            <input name="DR" placeholder="дд.мм.гггг" class="border border-primary rounded-start-3" />
                        </div>
                        <div class="col-12 mt-3">
                            <button type="submit" onclick="fnFindPolis(\'SearchFio\')" class="btn btn-primary text-light">Начать поиск</button>
                        </div>
                    </div>
                </form>
            </div>
            <!-- RESULT_DIV -->
            <div id="SearchFio_result" class="btn w-100 fw-bold mt-3 text-danger"></div>
        </div>

    </div>

    <div id="first">
        <a class="btn btn-primary my-3 w-100" data-bs-toggle="collapse" data-bs-target="#collapseFirst" aria-expanded="false" aria-controls="collapseExample">
            <div id="btnFirst" class="float-start d-inline-block text-nowrap">
                <img src="/images/web/enp_site.png" /> Проверить актуальность полиса старого образца
            </div>
        </a>

        <div class="collapse" id="collapseFirst">
            <div class="card card-body border-1 border-primary">
                <form id="SearchFirst" method="post">
                    <div class="form-group row">
                        <div class="col-12 mt-3">
                            <label>
                                Для поиска полиса старого образца необходимо заполнить <strong>cерию полиса, номер полиса и фамилию</strong> или <strong>серию полиса, номер полиса и дату рождения</strong>
                            </label>
                        </div>
                        <div class="col-12 mt-3">
                            <label>Серия полиса</label>
                            <input type="text" maxlength="20" name="SPOL" oninput="fnInputNumeric(this)" placeholder="Серия полиса" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-12 mt-3">
                            <label>Номер полиса</label>
                            <input type="text" maxlength="20" name="NPOL" oninput="fnInputNumeric(this)" placeholder="Номер полиса" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Фамилия</label>
                            <input type="text" name="FAM" placeholder="Фамилия" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Дата рождения</label>
                            <input name="DR" placeholder="дд.мм.гггг" class="border border-primary rounded-start-3" />
                        </div>
                        <div class="col-12 mt-3">
                            <button type="submit" onclick="fnFindPolis(\'SearchFirst\')" class="btn btn-primary text-light">Начать поиск</button>
                        </div>
                    </div>
                </form>
            </div>
            <!-- RESULT_DIV -->
            <div id="SearchFirst_result" class="btn w-100 fw-bold mt-3 text-danger"></div>
        </div>
    </div>

    <div id="second">
        <a class="btn btn-primary my-3 w-100" data-bs-toggle="collapse" data-bs-target="#collapseSecond" aria-expanded="false" aria-controls="collapseExample">
            <div id="btnSecond" class="float-start d-inline-block text-nowrap">
                <img src="/images/web/goznak_site.png" /> Проверить актуальность временного свидетельства
            </div>
        </a>

        <div class="collapse" id="collapseSecond">
            <div class="card card-body border-1 border-primary">
                <form id="SearchSecond" method="post">
                    <div class="form-group row">
                        <div class="col-12 mt-3">
                            <label>Для поиска временного свидетельства необходимо заполнить номер полиса и фамилию или номер полиса и дату рождения. 9 символов номера временного свидетельства заносятся в номер полиса.</label>
                        </div>
                        <div class="col-12 mt-3">
                            <label>Номер полиса</label>
                            <input type="text" maxlength="16" name="ENP" oninput="fnInputNumeric(this)" placeholder="Номер полиса" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Фамилия</label>
                            <input type="text" name="FAM" placeholder="Фамилия" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Дата рождения</label>
                            <input name="DR" placeholder="дд.мм.гггг" class="border border-primary rounded-start-3" />
                        </div>
                        <div class="col-12 mt-3">
                            <button type="submit" onclick="fnFindPolis(\'SearchSecond\')" class="btn btn-primary text-light">Начать поиск</button>
                        </div>
                    </div>
                </form>
            </div>
            <!-- RESULT_DIV -->
            <div id="SearchSecond_result" class="btn w-100 fw-bold mt-3 text-danger"></div>
        </div>
    </div>

    <div id="third">
        <a class="btn btn-primary my-3 w-100" data-bs-toggle="collapse" data-bs-target="#collapseThird" aria-expanded="false" aria-controls="collapseExample">
            <div id="btnThird" class="float-start d-inline-block text-nowrap">
                <img src="/images/web/polis_site.png" /> Проверить актуальность полиса единого образца
            </div>
        </a>

        <div class="collapse" id="collapseThird">
            <div class="card card-body border-1 border-primary">
                <form id="nSearchThird" method="post">
                    <div class="form-group row">
                        <div class="col-12 mt-3">
                            <label>Для поиска полиса единого образца необходимо заполнить <b>номер полиса и фамилию</b> или <b>номер полиса и дату рождения. 16 символов номера полиса единого образца</b> заносятся в номер полиса.</label>
                        </div>
                        <div class="col-12 mt-3">
                            <label>Единый номер полиса</label>
                            <input type="text" maxlength="16" name="ENP" oninput="fnInputNumeric(this)" placeholder="Единый номер полиса" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Фамилия</label>
                            <input type="text" name="FAM" placeholder="Фамилия" class="form-control border-1 border-primary rounded-3" />
                        </div>
                        <div class="col-6 mt-3">
                            <label>Дата рождения</label>
                            <input name="DR" placeholder="дд.мм.гггг" class="border border-primary rounded-start-3" />
                        </div>
                        <div class="col-12 mt-3">
                            <button type="submit" onclick="fnFindPolis(\'SearchThird\')" class="btn btn-primary text-light">Начать поиск</button>
                        </div>
                    </div>
                </form>
            </div>
            <!-- RESULT_DIV -->
            <div id="SearchThird_result" class="btn w-100 fw-bold mt-3 text-danger"></div>
        </div>
    </div>
</div>');
