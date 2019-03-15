--Delete all of the data
delete from survey_result;
delete from weather;
Delete from park;
delete from users;

--insert a fake park
INSERT park VALUES ('FNP', 'Fake National Park', 'Ohio', 3000, 500, 125, 0, 'Woodland', 2000, 2189849, 'Doesn''t matter', 'Doesn''t matter', 'Words', 10, 390);

--insert a fake weather day
insert weather values ('FNP', 1, 55, 65, 'cloudy');

--insert a fake user
insert into users (username,[password],salt,[role]) values ('testguy', 'password', 'saltsalt','user');

--insert a fake survey
insert into survey_result (parkCode,emailAddress,[state],activityLevel) values ('FNP', 'fakeguy@email.com', 'Ohio', 'doesn''t matter');
