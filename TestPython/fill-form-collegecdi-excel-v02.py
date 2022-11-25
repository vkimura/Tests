# fill form with data from a csv file
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import Select
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from xlrd import open_workbook
import re

# function to return all form elements xpath
def get_form_elements(web):
    form_elements = web.find_elements_by_xpath("//input[@type='text']")
    form_elements.extend(web.find_elements_by_xpath("//input[@type='checkbox']"))
    form_elements.extend(web.find_elements_by_xpath("//input[@type='radio']"))
    form_elements.extend(web.find_elements_by_xpath("//select"))
    return form_elements

def get_first_form(web):
    return web.find_element(By.XPATH, "/html/body/form[1]")  

def click_through_to_new_page(link_text):
    # link = web.find_element_by_link_text(link_text)
    link = web.find_element_by_xpath("//a[@class='ApplyNow']")
    link.click()

    def link_has_gone_stale():
        try:
            # poll the link with an arbitrary call
            link.find_elements_by_id('doesnt-matter') 
            return False
        except StaleElementReferenceException:
            return True

#TODO: add a wait for the page to load. Not working wait_for() and StaleElementReferenceException not defined 
    # wait_for(link_has_gone_stale)  

def create_variables_from_titles():
    []

options = webdriver.ChromeOptions()
options.add_experimental_option("detach", True)

wb = open_workbook("C:\\Users\\vkimura\\Documents\\Projects\\2022\\05\\09\\2022-06-08-1-colon-20PM.xls")
sheet = wb.sheet_by_index(0) # sheet 0
# sheet.cell_value(0, i)

import time, sys, csv

#get column names into a list
sheet.cell_value(0, 0) #get first row (i.e. column names)
columns = []
for i in range(sheet.ncols):
    columns.append(sheet.cell_value(0, i))

# example - update excel cell - https://www.geeksforgeeks.org/change-value-in-excel-using-python/

#get index from array of column names
# def get_index(column_name):
#     for i in range(sheet.ncols):
#     for i in range(sheet.ncols):
#         if sheet.cell_value(0, i) == column_name:
#              return i
indexSite = columns.index("Site")
indexURL = columns.index("URL")
indexForm = columns.index("Form")
indexIntlStudent = columns.index("Int'l student?")
indexStudyPermit = columns.index("Study permit")
indexRefugeeStatus = columns.index("Refugee status")
indexResideInCanada = columns.index("Reside in Canada")
indexCountry = columns.index("Country")
indexFirstName = columns.index("First Name")
indexLastName = columns.index("Last Name")
indexEmail = columns.index("Email")
indexPhone = columns.index("Phone")
indexPostal = columns.index("Postal")
indexProgram = columns.index("Program")
indexLandingPage = columns.index("Landing Page")
indexInLeadsTable = columns.index("In Leads Table")
indexFormNameByClass = columns.index("Form Name By Class")
indexXPATHFirstName = columns.index("XPATH First Name")
indexXPATHLastName = columns.index("XPATH Last Name")
indexXPATHGender = columns.index("XPATH Gender")
indexXPATHDate = columns.index("XPATH Date")
indexXPATHAddress = columns.index("XPATH Address")
indexXPATHCity = columns.index("XPATH City")
indexXPATHCountry = columns.index("XPATH Country")
indexXPATHPostal = columns.index("XPATH Postal")
indexXPATHPhone = columns.index("XPATH Phone")
indexXPATHGraduationYear = columns.index("XPATH Graduation Year")
indexXPATHProgram = columns.index("XPATH Program")
indexMyCollegeLeads = columns.index("MyCollegeLeads.ca")
setRowNumber = 58    # start at row 5
setSleepTimeLong = 2
setSleepTime = 1

print(indexURL)

web = webdriver.Chrome(options=options, executable_path="C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\Python39_64\\chromedriver.exe")
# column 2 in Excel
#web.get('https://www.collegecdi.loc/')
# web.get(sheet.cell_value(0, 2))
url = sheet.cell_value(setRowNumber, indexURL)
web.get(url)

#oFormElements = get_form_elements(web)
#oFirstForm = get_first_form(web)

# reference for wait - https://selenium-python.readthedocs.io/waits.html
# TODO: use WebDriverWait to wait for the page to load since it's more efficient rather than time.sleep()
# WebDriverWait(driver, 30, 0.5).until(EC.presence_of_element_located((By.CLASS_NAME, 'picture-img'))) 
# if we don't specify implicitly wait, error occur.
# because we will find element too quickly before we find element.
# driver.implicitly_wait(15)
# time.sleep(1)

#TODO: get all form elements
# content = web.find_element_by_tag_name('form')
# for input in content.find_elements_by_xpath('./input'):
#     print(input.get_attribute('name'))

time.sleep(setSleepTimeLong)

# https://selenium-python.readthedocs.io/locating-elements.html
# # username = driver.find_element(By.XPATH, "//form[input/@name='username']")
# username = driver.find_element(By.XPATH, "//form[@id='loginForm']/input[1]")
# username = driver.find_element(By.XPATH, "//input[@name='username']")
# 1. First form element with an input child element with name set to username
# 2. First input child element of the form element with attribute id set to loginForm
# 3. First input element with attribute name set to username

# web.find_element_by_xpath('//*[@id="tsf"]/div[2]/div[1]/div[1]/div/div[2]/input').send_keys('python')
# web.find_element_by_xpath('//*[@id="tsf"]/div[2]/div[1]/div[1]/div/div[2]/input').send_keys(Keys.ENTER)
# time.sleep(2)

#//*[@id="header-section-v2-id"]/div[1]/div/div/div[2]/a[1] - click on the "Apply Now" button (CDICollege)
#//*[@id="header-section-v2-id"]/div[1]/div/div/div[2]/a[1]  - click on the "Inscrivez-vous" button (CollegeCDI)
formName = sheet.cell_value(setRowNumber, indexForm)
if (formName == "Demande d'info" or formName =="Request Information"):
    web.find_element_by_xpath('//*[@id="right-menu-section-in-header-id"]/div/a').click() # click on the "Request Info"/"Demande d'info" button
elif (formName == "Inscrivez-vous" or formName =="Apply Now"):
    web.find_element_by_xpath('//*[@id="header-section-v2-id"]/div[1]/div/div/div[2]/a[1]').click() # click on the "Apply Now"/"Inscrivez-vous" button
elif (formName == "apply-now"):
    web.find_element_by_xpath("//a[@class='ApplyNow']").click() # click on the "Lead Form" button 
    # web.find_element_by_xpath("/html/body/header/a[4]").click() # click on the "Lead Form" button 
    # //input[@placeholder='First name *']
    # print("apply-now")

# check if new page is loaded - https://selenium-python.readthedocs.io/waits.html
# link_text = "Apply Now"
# click_through_to_new_page(link_text)

# time.sleep(setSleepTimeLong)
WebDriverWait(web, 7, 0.5).until(EC.presence_of_element_located((By.CLASS_NAME, indexFormNameByClass))) 

time.sleep(setSleepTimeLong)

# click on the "I am an international student" button - column 5 in Excel
    #//*[@id="int-yes"] - yes - landing page (CDICollege) - https://www.cdicollege.ca/business-office-administration-online-development-v3/ - template 158
    #//*[@id="int-no"] - no - landing page (CollegeCDI) - https://www.cdicollege.ca/business-office-administration-online-development-v3/ - template 158

siteName = sheet.cell_value(setRowNumber, indexSite)
intlStudentVal = sheet.cell_value(setRowNumber, indexIntlStudent)
if (siteName == "cdicollege"):
    if (intlStudentVal == "yes"):
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[1]/div/label[1]').click()
    else:
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[1]/div/label[2]').click()
elif (siteName == "collegecdi"):
    if (intlStudentVal.lower() == "yes"):
        web.find_element_by_xpath('//*[@id="int-yes2"]').click()
    else:
        web.find_element_by_xpath('//*[@id="int-no2"]').click()
elif (siteName == "vccollege"):
    if (url == "https://www.career.college/"):
        time.sleep(setSleepTime)
        if (formName == "lead-form"):
            web.find_element(By.XPATH, "//div[@class='RequestInfo']").click()
            time.sleep(setSleepTime)
            if(intlStudentVal == "yes"):
                web.find_element(By.XPATH, "//form[@class='lead-form']/label[@for='not_in_canada']").click()
                time.sleep(setSleepTime)
    elif (url == "https://www.reevescollege.ca/"):
        if (formName == "apply-now"):
            web.find_element(By.XPATH, indexXPATHFirstName).send_keys(sheet.cell_value(setRowNumber, indexFirstName))
# TODO: use excel cell value to find element by xpath(id), class name, etc.
                
# ref - https://stackoverflow.com/questions/20728331/xpath-pattern-for-all-specific-forms-in-html-page                
# example XPaths: //form[.//input[@type='password']][.//input[not(@type) or @type='' or @type='text']][.//input[@type='submit'] or .//button[not(@type) or @type='' or @type='submit']]

# //*[@id="int-no"] - https://www.collegecdi.loc/l-gestion-financiere-informatisee-lea.ac/
# //*[@id="submitRequestInfo"]/div[2]/div[3]/div[1]/div/label[1] - yes (CDICollege XPath)
# //*[@id="submitRequestInfo"]/div[2]/div[3]/div[1]/div/label[2] - no (CDICollege XPath)
#web.find_element_by_xpath('//*[@id="int-yes2"]').click()
#//*[@id="int-no2"] - no  (CollegeCDI XPath)

time.sleep(setSleepTime)    

#if the student is International, then the following other options apply; otherise, the other fields are not displayed.
if (intlStudentVal == "yes"):
        
    #click on the "Do you have a study permit in Canada?" button - column 6 in Excel
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[1] - yes (CDICollege XPath)
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[2] - no (CDICollege XPath)

        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[1] - yes (CollegeCDI XPath)
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[2] - no (CollegeCDI XPath)
    studyPermitVal = sheet.cell_value(setRowNumber, indexStudyPermit)
    if (studyPermitVal.lower() == "yes"):
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[1]').click()
    elif (studyPermitVal.lower() == "no"):
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[2]/div/label[2]').click()

    #click on the "Do you have a refugee status in Canada?" button - column 7 in Excel
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[1] - yes (CDICollege XPath)
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[2] - no (CDICollege XPath)

        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[1] - yes (CollegeCDI XPath)
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[2] - no (CollegeCDI XPath)

    time.sleep(setSleepTime)    

    refugeeStatusVal = sheet.cell_value(setRowNumber, indexRefugeeStatus)
    if (refugeeStatusVal.lower() == "yes"):
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[1]').click()
    elif (refugeeStatusVal.lower() == "no"):
        web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[3]/div/label[2]').click()

    time.sleep(setSleepTime)

    #click on "Do you have a Canadian address?" button - column 8 in Excel
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[4]/div/label[1] - yes (CDICollege XPath)
        #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[4]/div/label[2] - no (CDICollege XPath)

        #//*[@id="res-yes2"] - yes (CollegeCDI XPath)
        #web.find_element_by_xpath('//*[@id="res-no2"]').click() # click on the "I am not a resident of Canada" button

    if (siteName == "cdicollege"):
        if (sheet.cell_value(setRowNumber, indexResideInCanada).lower() == "yes"):
            web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[4]/div/label[1]').click() # click on the "yes" button
        else:
            web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[4]/div/label[2]').click() # click on the "no" button
    elif (siteName == "collegecdi"):
        if (sheet.cell_value(setRowNumber, indexResideInCanada).lower() == "yes"):
            web.find_element_by_xpath('//*[@id="res-yes2"]').click() # click on the "yes" button
        else:
            web.find_element_by_xpath('//*[@id="res-no2"]').click() # click on the "no" button  

    time.sleep(1)

    #check if country list selection is displayed
    strStyleCountryList = web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[5]').get_attribute('style')
    if (strStyleCountryList.find('display: none') == -1):
        selectCountryList = Select(web.find_element_by_xpath('//*[@id="CountryKey"]')) #can select by name using this variable
        web.find_element_by_xpath('//*[@id="CountryKey"]').send_keys(sheet.cell_value(setRowNumber, indexCountry))

    # enter "Canada" in the "Country" field - Country drop down - column 9 in Excel
    # web.find_element_by_xpath('//*[@id="CountryKey"]').send_keys('Canada')
        # web.find_element_by_xpath('//*[@id="CountryKey"]').send_keys(sheet.cell_value(setRowNumber, indexCountry))

time.sleep(1)

# enter "Timmy" in the "First Name" field - column 10 in Excel
#//*[@id="submitRequestInfo"]/div[2]/div[3]/div[6]/input - first name (CollegeCDI XPath)
#//*[@id="submitRequestInfo"]/div[2]/div[3]/div[6]/input - first name (CDICollege XPath)
if (siteName == "cdicollege" or siteName == "collegecdi"):
    # web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[6]/input').send_keys('Timmy')
    web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[6]/input').send_keys(sheet.cell_value(setRowNumber, indexFirstName))

#time.sleep(1)

# enter "Tom" in the "Last Name" field - column 11 in Excel
if (siteName == "cdicollege" or siteName == "collegecdi"):
    # web.find_elements_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[7]/input')[0].send_keys('Tom') 
    web.find_elements_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[7]/input')[0].send_keys(sheet.cell_value(setRowNumber, indexLastName)) 

#time.sleep(1)

# enter email in the "Email" field - column 12 in Excel
if (siteName == "cdicollege" or siteName == "collegecdi"):
    # web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[8]/input').send_keys('timmy@mailinator.com')
    web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[8]/input').send_keys(sheet.cell_value(setRowNumber, indexEmail))

#time.sleep(1)

# enter phone number in the "Phone" field - column 13 in Excel
if (siteName == "cdicollege" or siteName == "collegecdi"):
    # web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[9]/input').send_keys('123-343-3734')
    web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[9]/input').send_keys(sheet.cell_value(setRowNumber, indexPhone))

#time.sleep(1)

# enter postal in the "Postal Code" field - column 14 in Excel
if (siteName == "cdicollege" or siteName == "collegecdi"):
    # web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[10]/input').send_keys('V5X 5RT')
    web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[10]/input').send_keys(sheet.cell_value(setRowNumber, indexPostal))

time.sleep(1)

# define the "Program" drop-down
    #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[11]/select - program (CollegeCDI XPath)
    #//*[@id="submitRequestInfo"]/div[2]/div[3]/div[11]/select - program (CDICollege XPath)
    # strStyleCountryList = web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[5]').get_attribute('style')
    # select = Select(web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[11]/select'))
    # web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[11]/div/select').click()

time.sleep(1)

# select program from the drop-down - column 15 in Excel
selectProgram = Select(web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/div[3]/div[11]/select'))
selectProgram.select_by_visible_text(sheet.cell_value(setRowNumber, indexProgram))
# try:
#     select
# except NameError:
#     var_exists = False
# else:
#     var_exists = True
#     # select.select_by_visible_text('Gestion de l\'approvisionnement - LCA.FL')
#     select.select_by_visible_text(sheet.cell_value(setRowNumber, indexProgram))

#time.sleep(setSleepTime)

#web.find_element_by_xpath('//*[@id="submitRequestInfo"]/div[2]/button').click() # click on the "Submit" button

time.sleep(30)

    #web.close()
    #web.quit()














